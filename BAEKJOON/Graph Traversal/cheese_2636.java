package baekjoon.graph_traversal;

// 백준 - 치즈 2636
// https://www.acmicpc.net/problem/2636

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class cheese_2636 {

    public static final int EMPTY = 0;
    public static final int CHEESE = 1;
    public static final int MELTED = 2;

    public static int N, M;
    public static int cheeseCount = 0;

    public static int[][] board;
    public static boolean[][] visited;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        board = new int[N][M];
        visited = new boolean[N][M];
        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < M; j++) {
                board[i][j] = Integer.parseInt(st.nextToken());
                if (board[i][j] == CHEESE) cheeseCount++;
            }
        }

        int time = 0;
        int lastCheese = 0;
        while (cheeseCount != 0) {
            lastCheese = removeCheese(0, 0);
            time++;
            initBoard();
        }
        System.out.println(time + "\n" + lastCheese);
    }

    public static int removeCheese(int x, int y) {

        int lastCheese = 0;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});
        visited[x][y] = true;

        while(!queue.isEmpty()) {
            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= M) continue;

                if (board[nextX][nextY] == EMPTY && !visited[nextX][nextY]) {
                    queue.offer(new int[]{nextX, nextY});
                    visited[nextX][nextY] = true;
                } else if (board[nextX][nextY] == CHEESE) {
                    board[nextX][nextY] = MELTED;
                    cheeseCount--;
                    lastCheese++;
                }
            }
            if (cheeseCount == 0) break;
        }
        return lastCheese;
    }

    public static void initBoard() {
        visited = new boolean[N][M];
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) if (board[i][j] == MELTED) board[i][j] = EMPTY;
        }
    }
}
