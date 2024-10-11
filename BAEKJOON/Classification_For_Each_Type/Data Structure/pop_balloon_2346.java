package baekjoon.data_structure;

// 백준 - 풍선 터뜨리기 2346
// https://www.acmicpc.net/problem/2346

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class pop_balloon_2346 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        StringTokenizer st = new StringTokenizer(br.readLine());
        Deque<int[]> deque = new ArrayDeque<>();
        for (int i = 1; i <= N; i++) deque.offer(new int[]{i, Integer.parseInt(st.nextToken())});

        StringBuilder sb = new StringBuilder();
        int count = deque.poll()[1];
        sb.append("1").append(" ");
        while (deque.size() > 0) {
            if (count > 0) {
                for (int i = 1; i < count; i++) {
                    int[] temp = deque.poll();
                    deque.offer(temp);
                }
                int[] cur = deque.poll();
                sb.append(cur[0]).append(" ");
                count = cur[1];
            } else {
                count = Math.abs(count);
                for (int i = 1; i < count; i++) {
                    int[] temp = deque.pollLast();
                    deque.offerFirst(temp);
                }
                int[] cur = deque.pollLast();
                sb.append(cur[0]).append(" ");
                count = cur[1];
            }
        }
        System.out.println(sb);
    }
}

