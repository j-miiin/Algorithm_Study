
// 백준 - 카드2 2164
// https://www.acmicpc.net/problem/2164

package baekjoon.data_structure;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;

public class card2_2164 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        Queue<Integer> queue = new LinkedList<>();
        for (int i = 1; i <= N; i++) queue.offer(i);

        while (queue.size() > 1) {
            queue.poll();
            if (queue.size() == 1) break;
            int value = queue.poll();
            queue.offer(value);
        }
        System.out.println(queue.poll());
    }
}
