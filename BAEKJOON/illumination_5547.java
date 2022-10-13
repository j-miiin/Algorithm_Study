
// 백준 - 일루미네이션 5547
// https://www.acmicpc.net/problem/5547

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class illumination_5547 {

    public static final int EMPTY = 0;
    public static final int BUILDING = 1;

    public static int[] dx = {0, 1, 1, 0, -1, -1};
    public static int[][] dy = {{1, 0, -1, -1, -1, 0}, {1, 1, 0, -1, 0, 1}};

    public static int W, H;
    public static int[][] home;
    public static boolean[][] visited;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        W = Integer.parseInt(st.nextToken());
        H = Integer.parseInt(st.nextToken());
        home = new int[H+2][W+2];
        visited = new boolean[H+2][W+2];

        for (int i = 1; i <= H; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 1; j <= W; j++) {
                home[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        System.out.println(bfs(0, 0));
    }


    public static int bfs(int x, int y) {

        visited[x][y] = true;
        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});

        int wall = 0;

        while (!queue.isEmpty()) {
            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 6; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[curX%2][i];

                if (nextX < 0 || nextY < 0 || nextX >= H+2 || nextY >= W+2) continue;

                if (home[nextX][nextY] == EMPTY && !visited[nextX][nextY]) {
                    queue.offer(new int[]{nextX, nextY});
                    visited[nextX][nextY] = true;
                } else if (home[nextX][nextY] == BUILDING) {
                    wall++;
                }
            }
        }
        return wall;
    }
}
