
// BAEKJOON Gold 4
// Puyo Puyo : https://www.acmicpc.net/problem/11559

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;

public class week01_11559 {

    private static final int EMPTY = 0;
    private static final int RED = 1;
    private static final int GREEN = 2;
    private static final int BLUE = 3;
    private static final int PURPLE = 4;
    private static final int YELLOW = 5;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int[][] puyoArr;
    public static boolean[][] visited;

    public static Queue<int[]> queue = new LinkedList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        puyoArr = new int[12][6];
        visited = new boolean[12][6];

        for (int i = 0; i < 12; i++) {
            String str = br.readLine();
            for (int j = 0; j < 6; j++) {
                Character c = str.charAt(j);
                if (c == '.') {
                    puyoArr[i][j] = EMPTY;
                } else if (c == 'R') {
                    puyoArr[i][j] = RED;
                    queue.offer(new int[]{i, j});
                    visited[i][j] = true;
                } else if (c == 'G') {
                    puyoArr[i][j] = GREEN;
                    queue.offer(new int[]{i, j});
                    visited[i][j] = true;
                } else if (c == 'B') {
                    puyoArr[i][j] = BLUE;
                    queue.offer(new int[]{i, j});
                    visited[i][j] = true;
                } else if (c == 'P') {
                    puyoArr[i][j] = PURPLE;
                    queue.offer(new int[]{i, j});
                    visited[i][j] = true;
                } else if (c == 'Y') {
                    puyoArr[i][j] = YELLOW;
                    queue.offer(new int[]{i, j});
                    visited[i][j] = true;
                }
            }
        }
    }

    public static void popPuyo() {

        int r = 0, g = 0, b = 0, p = 0, y = 0;

        int qSize = queue.size();

        while(!queue.isEmpty()) {

            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX >= 0 && nextY >= 0 && nextX < 12 && nextY < 6 && !visited[nextX][nextY]) {
                    int nextPuyo = puyoArr[nextX][nextY];
                    if (nextPuyo != EMPTY && puyoArr[curX][curY] == nextPuyo) {

                        queue.offer(new int[]{nextX, nextY});
                        visited[nextX][nextY] = true;

                        if (nextPuyo == RED) r++;
                        else if (nextPuyo == GREEN) g++;
                        else if (nextPuyo == BLUE) b++;
                        else if (nextPuyo == PURPLE) p++;
                        else if (nextPuyo == YELLOW) y++;
                    }
                }
            }
        }
    }
}
