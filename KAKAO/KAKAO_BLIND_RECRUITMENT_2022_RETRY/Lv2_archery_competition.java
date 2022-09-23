package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv2 양궁 대회 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92342

public class Lv2_archery_competition {

    public static int N;
    public static int[] apeachInfo;
    public static int[] lionInfo;
    public static int[] result;
    public static int scoreDiff = Integer.MIN_VALUE;

    public static void main(String[] args) {
//        int n = 5;
//        int[] info = {2,1,1,1,0,0,0,0,0,0,0};

//        int n = 1;
//        int[] info = {1,0,0,0,0,0,0,0,0,0,0};

//        int n = 9;
//        int[] info = {0,0,1,2,0,1,1,1,1,1,1};

        int n = 10;
        int[] info = {0,0,0,0,0,0,0,0,3,4,3};

        int[] answer = solution(n, info);
        for (int i = 0; i < answer.length; i++) {
            System.out.println(answer[i]);
        }
    }

    public static int[] solution(int n, int[] info) {

        N = n;
        apeachInfo = info;
        lionInfo = new int[11];
        result = new int[11];

        play(0);

        int[] answer = (scoreDiff > 0) ? result : new int[]{-1};
        return answer;
    }

    public static void play(int shoot) {

        if (shoot == N) {
            int curResult = calculateScoreDiff();
            if (curResult > 0 && curResult >= scoreDiff) {
                scoreDiff = curResult;
                for (int i = 0; i < lionInfo.length; i++) result[i] = lionInfo[i];
            }
            return;
        }

        for (int i = 0; i <= 10 && lionInfo[i] <= apeachInfo[i]; i++) {
            lionInfo[i]++;
            play(shoot + 1);
            lionInfo[i]--;
        }
    }

    public static int calculateScoreDiff() {

        int apeach = 0;
        int lion = 0;
        for (int i = 0; i < 11; i++) {
            if (lionInfo[i] > apeachInfo[i]) lion += (10-i);
            else if (apeachInfo[i] != 0) apeach += (10-i);
        }

        return lion-apeach;
    }
}
