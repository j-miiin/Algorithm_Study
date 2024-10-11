package baekjoon.data_structure;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class queue2_18258 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        Queue<Integer> queue = new LinkedList<>();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < N; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            String command = st.nextToken();

            if (command.equals("push")) {
                queue.offer(Integer.parseInt(st.nextToken()));
            } else if (command.equals("pop")) {
                sb.append((queue.size() >= 1) ? queue.poll() : -1).append("\n");
            } else if (command.equals("size")) {
                sb.append(queue.size()).append("\n");
            } else if (command.equals("empty")) {
                sb.append((queue.size() != 0) ? 0 : 1).append("\n");
            } else if (command.equals("front")) {
                sb.append((queue.size() >= 1) ? queue.peek() : -1).append("\n");
            } else if (command.equals("back")) {
                if (queue.size() == 0) sb.append("-1").append("\n");
                else {
                    Integer[] arr = new Integer[queue.size()];
                    arr = queue.toArray(arr);
                    sb.append(arr[arr.length-1]).append("\n");
                }
            }
        }

        System.out.println(sb);
    }
}
