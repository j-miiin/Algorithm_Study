package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv2 주차 요금 계산 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92341

import java.util.Arrays;
import java.util.HashMap;
import java.util.StringTokenizer;

public class Lv2_calculate_parking_fee {

    public static final String lastTime = "23:59";

    public static void main(String[] args) {
//        int[] fees = {180, 5000, 10, 600};
//        String[] records = {"05:34 5961 IN", "06:00 0000 IN", "06:34 0000 OUT", "07:59 5961 OUT", "07:59 0148 IN", "18:59 0000 IN", "19:09 0148 OUT", "22:59 5961 IN", "23:00 5961 OUT"};

        int[] fees = {120, 0, 60, 591};
        String[] records = {"16:00 3961 IN","16:00 0202 IN","18:00 3961 OUT","18:00 0202 OUT","23:58 3961 IN"};

//        int[] fees = {1, 461, 1, 10};
//        String[] records ={"00:00 1234 IN"};

        int[] result = solution(fees, records);
        for (int i : result) {
            System.out.println(i);
        }
    }

    public static int[] solution(int[] fees, String[] records) {

        HashMap<String, String> inoutRecord = new HashMap<>();
        HashMap<String, Integer> feeRecord = new HashMap<>();

        for (String s : records) {
            StringTokenizer st = new StringTokenizer(s);
            String time = st.nextToken();
            String carNum = st.nextToken();
            String inOrOut = st.nextToken();

            if (inOrOut.equals("IN")) inoutRecord.put(carNum, time);
            else {
                int t = timeDiff(inoutRecord.get(carNum), time);
                feeRecord.put(carNum, feeRecord.getOrDefault(carNum, 0) + t);
                inoutRecord.put(carNum, lastTime);
            }
        }

        for (String key : inoutRecord.keySet()) {
            if (!inoutRecord.get(key).equals(lastTime)) {
                int t = timeDiff(inoutRecord.get(key), lastTime);
                feeRecord.put(key, feeRecord.getOrDefault(key, 0) + t);
            }
        }

        String[] key = feeRecord.keySet().toArray(new String[0]);
        Arrays.sort(key);
        int[] answer = new int[key.length];
        int idx = 0;
        for (String k :key) {
            answer[idx++] = calculateFee(feeRecord.get(k), fees);
        }

        return answer;
    }

    public static int timeDiff(String inTime, String outTime) {
        StringTokenizer st = new StringTokenizer(inTime, ":");
        int inHour = Integer.parseInt(st.nextToken());
        int inMinute = Integer.parseInt(st.nextToken());
        int in = inHour*60 + inMinute;

        st = new StringTokenizer(outTime, ":");
        int outHour = Integer.parseInt(st.nextToken());
        int outMinute = Integer.parseInt(st.nextToken());
        int out = outHour*60 + outMinute;

        return out-in;
    }

    public static int calculateFee(int t, int[] fees) {
        int defaultTime = fees[0];
        int defaultFee = fees[1];
        int unitTime = fees[2];
        int unitFee = fees[3];

        if (t <= defaultTime) return defaultFee;
        else return defaultFee + ((int)Math.ceil((double)(t - defaultTime) / unitTime))*unitFee;
    }
}
