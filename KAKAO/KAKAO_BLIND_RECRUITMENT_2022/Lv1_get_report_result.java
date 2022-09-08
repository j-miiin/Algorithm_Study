import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class Lv1_get_report_result {

    public static void main(String[] args) throws IOException {
        String[] id_list = {"muzi", "frodo", "apeach", "neo"};
        String[] report = {"muzi frodo", "apeach frodo", "frodo neo", "muzi neo", "apeach muzi"};

        int[] result = solution(id_list, report, 2);
        for (int i = 0; i < result.length; i++) {
            System.out.println(result[i]);
        }
    }

    public static int[] solution(String[] id_list, String[] report, int k) {

        int numOfUser = id_list.length;

        HashSet<String>[] arr = new HashSet[numOfUser];
        for (int i = 0; i < numOfUser; i++) {
            arr[i] = new HashSet();
        }

        for (int i = 0; i < report.length; i++) {
            StringTokenizer st = new StringTokenizer(report[i]);
            String userId = st.nextToken();
            String reportedId = st.nextToken();

            int index = getUserIdIndex(reportedId, id_list);
            arr[index].add(userId);
        }

        int[] answer = {};
        answer = new int[numOfUser];

        for (int i = 0; i < numOfUser; i++) {
            if (arr[i].size() >= k) {
                for (String userName: arr[i]) {
                    int index = getUserIdIndex(userName, id_list);
                    answer[index]++;
                }
            }
        }

        return answer;
    }

    public static int getUserIdIndex(String userId, String[] id_list) {
        for (int i = 0; i < id_list.length; i++) {
            if (userId.equals(id_list[i])) {
                return i;
            }
        }
        return -1;
    }
}
