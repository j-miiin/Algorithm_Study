
// 백준 - 토마토 7569
// https://www.acmicpc.net/problem/7569

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class tomato_7569 {

    public static final int TOMATO = 0;
    public static final int RIPEN = 1;
    public static final int EMPTY = -1;

    public static int[] dx = {-1, 1, 0, 0, 0, 0};
    public static int[] dy = {0, 0, -1, 1, 0, 0};
    public static int[] dh = {0, 0, 0, 0, -1, 1};

    public static int N, M, H;
    public static int[][][] box;
    public static int[][][] days;

    public static Queue<int[]> queue = new LinkedList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        M = Integer.parseInt(st.nextToken());
        N = Integer.parseInt(st.nextToken());
        H = Integer.parseInt(st.nextToken());
        box = new int[N][M][H];
        days = new int[N][M][H];
        for (int[][] i : days) {
            for (int[] j : i) {
                Arrays.fill(j, -1);
            }
        }

        for (int i = 0; i < H; i++) {
            for (int j = 0; j < N; j++) {
                st = new StringTokenizer(br.readLine());
                for (int k = 0; k < M; k++) {
                    int cur = Integer.parseInt(st.nextToken());
                    box[j][k][i] = cur;
                    if (cur == RIPEN) {
                        queue.offer(new int[]{j, k, i});
                        days[j][k][i] = 0;
                    }
                }
            }
        }

        int result = bfs();
        boolean isAllRipen = true;
        for (int i = 0; i < H; i++) {
            for (int j = 0; j < N; j++) {
                for (int k = 0; k < M; k++) {
                    if (box[j][k][i] == TOMATO) {
                        isAllRipen = false;
                        break;
                    }
                }
            }
        }
        System.out.println((isAllRipen) ? result : -1);
    }

    public static int bfs() {

        int count = 0;

        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];
            int curH = cur[2];

            for (int i = 0; i < 6; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];
                int nextH = curH + dh[i];

                if (nextX < 0 || nextY < 0 || nextH < 0 || nextX >= N || nextY >= M || nextH >= H
                        || days[nextX][nextY][nextH] != -1) continue;

                if (box[nextX][nextY][nextH] == TOMATO) {
                    box[nextX][nextY][nextH] = RIPEN;
                    days[nextX][nextY][nextH] = days[curX][curY][curH] + 1;
                    count = Math.max(count, days[nextX][nextY][nextH]);
                    queue.offer(new int[]{nextX, nextY, nextH});
                }

            }
        }
        return count;
    }
}
