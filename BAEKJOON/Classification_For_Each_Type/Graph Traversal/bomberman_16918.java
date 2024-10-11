
// 백준 - 봄버맨 16918
// https://www.acmicpc.net/problem/16918

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class bomberman_16918 {

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static final int EMPTY = 1;

    public static int R, C, N;
    public static int[][] board;

    public static int second = 0;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        R = Integer.parseInt(st.nextToken());
        C = Integer.parseInt(st.nextToken());
        N = Integer.parseInt(st.nextToken());

        board = new int[R][C];
        Queue<int[]> queue = new LinkedList<>();
        for (int i = 0; i < R; i++) {
            String s = br.readLine();
            for (int j = 0; j < C; j++) {
                if (s.charAt(j) == '.') board[i][j] = EMPTY;
                else {
                    board[i][j] = second;
                    queue.offer(new int[]{i, j});
                }
            }
        }
        second = 1;
        bfs();

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < R; i++) {
            for (int j = 0; j < C; j++) {
                if (board[i][j] == EMPTY) sb.append(".");
                else sb.append("O");
            }
            sb.append("\n");
        }
        System.out.println(sb);
    }

    public static void bfs() {

        while (true) {

            if (second % 2 == 0) {
                plantBomb();
            } else if (second > 1 && second % 2 != 0) {
                int cur = second - 3;
                Queue<int[]> queue = findBomb(cur);
                while (!queue.isEmpty()) {
                    int[] pos = queue.poll();
                    int posX = pos[0];
                    int posY = pos[1];
                    board[posX][posY] = EMPTY;

                    for (int i = 0; i < 4; i++) {
                        int nextX = posX + dx[i];
                        int nextY = posY + dy[i];

                        if (nextX < 0 || nextY < 0 || nextX >= R || nextY >= C) continue;

                        if (board[nextX][nextY] != EMPTY) board[nextX][nextY] = EMPTY;
                    }
                }
            }

            if (second == N) return;

            second++;
        }
    }

    public static void plantBomb() {

        for (int i = 0; i < R; i++) {
            for (int j = 0; j < C; j++) {
                if (board[i][j] == EMPTY) board[i][j] = second;
            }
        }
    }

    public static Queue<int[]> findBomb(int curSecond) {
        Queue<int[]> queue = new LinkedList<>();
        for (int i = 0; i < R; i++) {
            for (int j = 0; j < C; j++) {
                if (board[i][j] == curSecond) queue.offer(new int[]{i, j});
            }
        }
        return queue;
    }
}
