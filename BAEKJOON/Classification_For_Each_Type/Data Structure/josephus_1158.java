
// 백준 - 요세푸스 문제 1158
// https://www.acmicpc.net/problem/1158

package baekjoon.data_structure;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class josephus_1158 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());

        StringBuilder sb = new StringBuilder();
        sb.append("<");
        Queue<Integer> queue = new LinkedList<>();
        for (int i = 1; i <= N; i++) queue.offer(i);

        while (!queue.isEmpty()) {

            for (int i = 0; i < K-1; i++) {
                int cur = queue.poll();
                queue.offer(cur);
            }

            sb.append(queue.poll()).append(", ");
        }
        sb.replace(sb.length()-2, sb.length()-1, ">");
        System.out.println(sb);
    }
}
