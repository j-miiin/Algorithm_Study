package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv1 신고 결과 받기 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92334

import java.util.HashMap;
import java.util.HashSet;
import java.util.StringTokenizer;

public class Lv1_get_report_result {
    public static void main(String[] args) {
        String[] id_list = {"con", "ryan"};
        String[] report = {"ryan con", "ryan con", "ryan con", "ryan con"};

        int[] result = solution(id_list, report, 3);
        for (int i = 0; i < result.length; i++) {
            System.out.println(result[i]);
        }
    }

    public static int[] solution(String[] id_list, String[] report, int k) {

        HashMap<String, HashSet<String>> reportedCount = new HashMap<>();
        for (String s : id_list) reportedCount.put(s, new HashSet<>());

        for (String s : report) {
            StringTokenizer st = new StringTokenizer(s);
            String user = st.nextToken();
            String reported = st.nextToken();

            reportedCount.get(reported).add(user);
        }

        HashMap<String, Integer> result = new HashMap<>();
        for (String s : id_list) {
            HashSet<String> cur = reportedCount.get(s);
            if (cur.size() >= k) {
                for (String name : cur) result.put(name, result.getOrDefault(name, 0)+1);
            }
        }

        int[] answer = new int[id_list.length];
        int idx = 0;
        for (String s : id_list) {
            answer[idx++] = result.get(s) != null ? result.get(s) : 0;
        }

        return answer;
    }
}
