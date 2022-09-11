package kakao_blind_recruitment_2021;

// 2021 카카오 블라인드 채용

import java.util.StringTokenizer;

public class Lv3_add_ad {
    public static void main(String[] args) {

//        String play_time = "02:03:55";
//        String adv_time = "00:14:15";
//        String[] logs = {"01:20:15-01:45:14", "00:40:31-01:00:00", "00:25:50-00:48:29", "01:30:59-01:53:29", "01:37:44-02:02:30"};

        String play_time = "50:00:00";
        String adv_time = "50:00:00";
        String[] logs = {"15:36:51-38:21:49", "10:14:18-15:36:51", "38:21:49-42:51:45"};

        System.out.println(solution(play_time, adv_time, logs));
    }

    public static String solution(String play_time, String adv_time, String[] logs) {

        int playTime = stringToSecond(play_time);
        int advTime = stringToSecond(adv_time);

        long[] viewer = new long[playTime + 1];

        for (int i = 0; i < logs.length; i++) {
            StringTokenizer st = new StringTokenizer(logs[i], "-");
            int start = stringToSecond(st.nextToken());
            int end = stringToSecond(st.nextToken());

            viewer[start]++;
            viewer[end]--;
        }

        for (int i = 1; i < playTime; i++) {
            viewer[i] += viewer[i - 1];
        }

        for (int i = 1; i < playTime; i++) {
            viewer[i] += viewer[i - 1];
        }

        int maxTime = 0;
        long maxRet = viewer[advTime - 1];

        for (int i = advTime; i < viewer.length; i++) {
            if (maxRet < viewer[i] - viewer[i - advTime]) {
                maxRet = viewer[i] - viewer[i - advTime];
                maxTime = i - advTime + 1;
            }
        }

        String answer = secondToString(maxTime);
        return answer;
    }

    public static int stringToSecond(String time) {
        StringTokenizer st = new StringTokenizer(time, ":");
        int hour = Integer.parseInt(st.nextToken()) * 3600;
        int minute = Integer.parseInt(st.nextToken()) * 60;
        int second = Integer.parseInt(st.nextToken());

        return hour + minute + second;
    }

    public static String secondToString(int time) {
        String result = "";

        int h = time / 3600;
        time = time - h * 3600;
        int m = time / 60;
        time = time - m * 60;
        int s = time;

        if (h < 10) result += "0";
        result += h + ":";
        if (m < 10) result += "0";
        result += m + ":";
        if (s < 10) result += "0";
        result += s;

        return result;
    }
}
