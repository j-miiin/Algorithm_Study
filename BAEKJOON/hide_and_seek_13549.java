
// 백준 - 숨바꼭질 3 13549
// https://www.acmicpc.net/problem/13549

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class hide_and_seek_13549 {

    public static int N, K;
    public static int[] visited = new int[100001];

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        K = Integer.parseInt(st.nextToken());

        Arrays.fill(visited, Integer.MAX_VALUE);

        if (N == K) System.out.println(0);
        else bfs();
    }

    public static void bfs() {
        Queue<Integer> queue = new LinkedList<>();
        queue.offer(N);
        visited[N] = 0;

        while(!queue.isEmpty()) {
            int cur = queue.poll();

            for(int i = 0; i < 3; i++) {
                int next;
                int second;
                if (i == 0) {
                    next = cur * 2;
                    second = 0;
                }
                else if (i == 1) {
                    next = cur - 1;
                    second = 1;
                }
                else {
                    next = cur + 1;
                    second = 1;
                }

                if (next >= 0 && next <= 100000 && visited[next] == Integer.MAX_VALUE) {
                    queue.offer(next);
                    visited[next] = Math.min(visited[next], visited[cur] + second);
                }

                if (next == K) {
                    System.out.println(visited[next]);
                    return;
                }
            }
        }
    }
}
