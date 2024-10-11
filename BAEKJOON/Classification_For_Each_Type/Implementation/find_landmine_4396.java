
// 백준 - 지뢰 찾기 4396
// https://www.acmicpc.net/problem/4396

package baekjoon.implementation;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class find_landmine_4396 {

    public static final int EMPTY = 0;
    public static final int MINE = 1;

    public static int N;
    public static int[][] board;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());
        board = new int[N][N];
        ArrayList<int[]> mineList = new ArrayList<>();
        for (int i = 0; i < N; i++) {
            String str = br.readLine();
            for (int j = 0; j < N; j++) {
                if (str.charAt(j) == '.') board[i][j] = EMPTY;
                else {
                    board[i][j] = MINE;
                    mineList.add(new int[]{i, j});
                }
            }
        }

        String[][] result = new String[N][N];
        boolean isOver = false;
        for (int i = 0; i < N; i++) {
            String str = br.readLine();
            for (int j = 0; j < N; j++) {
                if (str.charAt(j) == 'x' && board[i][j] == EMPTY) result[i][j] = checkMine(i, j) + "";
                else if (str.charAt(j) == 'x' && board[i][j] == MINE) {
                    isOver = true;
                }
                else result[i][j] = ".";
            }
        }

        if (isOver) {
            for (int[] i : mineList) result[i[0]][i[1]] = "*";
        }

        StringBuilder sb = new StringBuilder();
        for (String[] str : result) {
            for (String s : str) sb.append(s);
            sb.append("\n");
        }
        System.out.println(sb);
    }

    public static int checkMine(int x, int y) {
        int[] dx = {-1, 1, 0, 0, -1, 1, -1, 1};
        int[] dy = {0, 0, -1, 1, -1, 1, 1, -1};

        int count = 0;
        for (int i = 0; i < 8; i++) {
            int nextX = x + dx[i];
            int nextY = y + dy[i];

            if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N) continue;

            if (board[nextX][nextY] == MINE) count++;
        }
        return count;
    }
}
