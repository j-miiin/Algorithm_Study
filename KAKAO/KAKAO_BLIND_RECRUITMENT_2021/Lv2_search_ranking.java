package kakao_blind_recruitment_2021;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.StringTokenizer;

public class Lv2_search_ranking {


    public static void main(String[] args) {

        String[] info = {"java backend junior pizza 150","python frontend senior chicken 210","python frontend senior chicken 150","cpp backend senior pizza 260","java backend junior chicken 80","python backend senior chicken 50"};
        String[] query = {"java and backend and junior and pizza 100","python and frontend and senior and chicken 200","cpp and - and senior and pizza 250","- and backend and senior and - 150","- and - and - and chicken 100","- and - and - and - 150"};

        int[] result = solution(info, query);
        for (int i : result) {
            System.out.println(i);
        }
    }

    public static int[] solution(String[] info, String[] query) {
        HashMap<String, ArrayList<Integer>> applicantInfo = new HashMap<>();

        for (int i = 0; i < info.length; i++) {
            StringTokenizer st = new StringTokenizer(info[i]);
            String lng = st.nextToken();
            String job = st.nextToken();
            String career = st.nextToken();
            String food = st.nextToken();
            int score = Integer.parseInt(st.nextToken());

            String[] keys = makeKey(lng, job, career, food);
            for (String key : keys) {
                if (key != null) {
                    if (applicantInfo.get(key) == null) {
                        applicantInfo.put(key, new ArrayList<>());
                    }
                    applicantInfo.get(key).add(score);
                }
            }
        }

        for (String mapKey : applicantInfo.keySet()) {
            Collections.sort(applicantInfo.get(mapKey));
        }

        int[] answer = new int[query.length];

        for (int i = 0; i < query.length; i++) {
            String queryStr = query[i].replaceAll("and", " ");
            StringTokenizer st = new StringTokenizer(queryStr);

            String lng = st.nextToken();
            String job = st.nextToken();
            String career = st.nextToken();
            String food = st.nextToken();
            int score = Integer.parseInt(st.nextToken());

            String key = lng + job + career + food;

            int count = 0;
            ArrayList<Integer> cur = applicantInfo.get(key);
            if (cur != null) {
                answer[i] = cur.size() - lowerBound(cur, score);
            } else answer[i] = count;
        }

        return answer;
    }

    public static String[] makeKey(String lng, String job, String career, String food) {
        String[] keys = new String[20];

        String[] lngStr = {lng, "-"};
        String[] jobStr = {job, "-"};
        String[] careerStr = {career, "-"};
        String[] foodStr = {food, "-"};

        int idx = 0;
        for (String s_lng : lngStr) {
            for (String s_job : jobStr) {
                for (String s_career : careerStr) {
                    for (String s_food : foodStr) {
                        String key = s_lng + s_job + s_career + s_food;
                        keys[idx++] = key;
                    }
                }
            }
        }

        return keys;
    }

    public static int lowerBound(ArrayList<Integer> list, int pivot) {
        int left = 0, right = list.size() - 1;

        while (left <= right) {
            int mid = (left + right) / 2;

            if (list.get(mid) < pivot)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return left;
    }
}
