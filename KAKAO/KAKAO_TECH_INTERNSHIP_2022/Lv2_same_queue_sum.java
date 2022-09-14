package kakao_tech_internship_2022;

import java.util.ArrayList;

public class Lv2_same_queue_sum {

    public static ArrayList<Integer> queueList = new ArrayList<>();

    public static void main(String[] args) {

//        int[] queue1 = {3, 2, 7, 2};
//        int[] queue2 = {4, 6, 5, 1};

//        int[] queue1 = {1, 2, 1, 2};
//        int[] queue2 = {1, 10, 1, 2};

        int[] queue1 = {1, 1};
        int[] queue2 = {1, 5};

        System.out.println(solution(queue1, queue2));
    }

    public static int solution(int[] queue1, int[] queue2) {

        long sum = 0;
        long curSum = 0;
        for (int i = 0; i < queue1.length; i++) {
            queueList.add(queue1[i]);
            sum += queue1[i];
            curSum += queue1[i];
        }

        for (int i = 0; i < queue2.length; i++) {
            queueList.add(queue2[i]);
            sum += queue2[i];
        }

        for (int i : queue1) queueList.add(i);
        for (int i : queue2) queueList.add(i);

        if (sum % 2 != 0) {
            return -1;
        }

        int answer = rearrangeQueueList(sum/2, curSum, 0, queue1.length);

        return answer;
    }

    public static int rearrangeQueueList(long avg, long curSum, int start, int end) {

        int count = 0;
        int s = start, e = end;

        while (count <= queueList.size()) {

            if (curSum < avg) {
                curSum += queueList.get(e);
                e++;
                count++;
            }
            else if (curSum > avg) {
                curSum -= queueList.get(s);
                s++;
                count++;
            }
            else if (curSum == avg) return count;
        }

        return -1;
    }
}
