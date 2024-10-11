
// 백준 - 쉬운 최단거리 14940
// https://www.acmicpc.net/problem/14940

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class easy_shortest_distance_14940 {

    public static final int WALL = 0;
    public static final int EMPTY = 1;
    public static final int DESTINATION = 2;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int n, m;
    public static int[][] area;
    public static int[][] distance;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        n = Integer.parseInt(st.nextToken());
        m = Integer.parseInt(st.nextToken());
        area = new int[n][m];
        distance = new int[n][m];

        int desX = 0, desY = 0;
        for (int i = 0; i < n; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < m; j++) {
                int cur = Integer.parseInt(st.nextToken());
                area[i][j] = cur;
                if (cur == DESTINATION) {
                    desX = i;
                    desY = j;
                }
            }
        }

        for (int[] i : distance) {
            Arrays.fill(i, -1);
        }

        bfs(desX, desY);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                if (area[i][j] == WALL) sb.append(WALL).append(" ");
                else sb.append(distance[i][j]).append(" ");
            }
            sb.append("\n");
        }
        System.out.println(sb);
    }

    public static void bfs(int x, int y) {

        distance[x][y] = 0;
        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});

        while (!queue.isEmpty()) {

            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= n || nextY >= m || area[nextX][nextY] == WALL) continue;

                if (distance[nextX][nextY] == -1) {
                    distance[nextX][nextY] = distance[curX][curY] + 1;
                    queue.offer(new int[]{nextX, nextY});
                } else {
                    distance[nextX][nextY] = Math.min(distance[nextX][nextY], distance[curX][curY] + 1);
                }
            }
        }
    }
}
