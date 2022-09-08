
// 2022 카카오 블라인드 채용

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.StringTokenizer;

public class Lv2_calculate_parking_fee {
    public static void main(String[] args) {

//        int[] fees = {180, 5000, 10, 600};
//        String[] records = {"05:34 5961 IN", "06:00 0000 IN", "06:34 0000 OUT", "07:59 5961 OUT", "07:59 0148 IN", "18:59 0000 IN", "19:09 0148 OUT", "22:59 5961 IN", "23:00 5961 OUT"};

        int[] fees = {1, 461, 1, 10};
        String[] records ={"00:00 1234 IN"};

        int[] result = solution(fees, records);
        for (int i : result) {
            System.out.println(i);
        }
    }

    public static int[] solution(int[] fees, String[] records) {

        String lastTime = "23:59";

        HashMap<String, String> recordsMap = new HashMap<>();
        HashMap<String, Integer> timeMap = new HashMap<>();

        for (int i = 0; i < records.length; i++) {
            StringTokenizer st = new StringTokenizer(records[i]);
            String time = st.nextToken();
            String carNum = st.nextToken();
            String inOrOut = st.nextToken();

            if (inOrOut.equals("IN")) {
                recordsMap.put(carNum, time);
            } else {
                String inTime = recordsMap.get(carNum);
                int parkingTime = calculateParkingTime(inTime, time);
                int temp = parkingTime;
                if (timeMap.containsKey(carNum)) {
                    temp += timeMap.get(carNum);
                }
                timeMap.put(carNum, temp);
                recordsMap.remove(carNum);
            }
        }

        for (String key: recordsMap.keySet()) {
            String inTime = recordsMap.get(key);
            int parkingTime = calculateParkingTime(inTime, lastTime);
            int temp = parkingTime;
            if (timeMap.containsKey(key)) {
                temp += timeMap.get(key);
            }
            timeMap.put(key, temp);
        }

        int[] answer = calculateParkingFee(fees, timeMap);
        return answer;
    }

    public static int calculateParkingTime(String inTime, String outTime) {
        String[] inTimes = inTime.split(":");
        int inHour = Integer.parseInt(inTimes[0]);
        int inMinute = Integer.parseInt(inTimes[1]);

        String[] outTimes = outTime.split(":");
        int outHour = Integer.parseInt(outTimes[0]);
        int outMinute = Integer.parseInt(outTimes[1]);

        int resultTime = 0;

        if (outMinute < inMinute) {
            outHour--;
            outMinute += 60;
        }

        resultTime += (outMinute - inMinute);
        resultTime += (outHour - inHour) * 60;

        return resultTime;
    }

    public static int[] calculateParkingFee(int[] fees, HashMap<String, Integer> timeMap) {

        int defaultTime = fees[0];
        int defaultFee = fees[1];
        int unitTime = fees[2];
        int unitFee = fees[3];

        List<String> keyList = new ArrayList<>(timeMap.keySet());
        keyList.sort(String::compareTo);

        int[] resultFee = new int[keyList.size()];
        int idx = 0;

        for (String key: keyList) {
            int curTime = timeMap.get(key);

            if (curTime <= defaultTime) {
                resultFee[idx++] = defaultFee;
            } else {
                int fee = defaultFee + (int)Math.ceil((double)(curTime - defaultTime) / unitTime) * unitFee;
                resultFee[idx++] = fee;
            }
        }

        return resultFee;
    }
}
