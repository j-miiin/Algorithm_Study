
// 백준 - 빙고 2578
// https://www.acmicpc.net/problem/2578

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class bingo_2578 {

    public static final int size = 5;
    public static int[][] board = new int[size][size];
    public static int[][] answer = new int[size][size];

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        for (int i = 0; i < size; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int j = 0; j < size; j++) {
                board[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        int turn = 0;
        for (int i = 0; i < size; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int j = 0; j < size; j++) {
                deleteNum(Integer.parseInt(st.nextToken()));
                turn++;
                if (checkBingo()) {
                    System.out.println(turn);
                    return;
                }
            }
        }
    }

    public static void deleteNum(int n) {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                if (board[i][j] == n) {
                    board[i][j] = 0;
                }
            }
        }
    }

    public static boolean checkBingo() {
        int count = 0;
        boolean bingo = true;

        for (int i = 0; i < size; i++) {
            bingo = true;
            for (int j = 0; j < size; j++) {
                if (board[i][j] != 0) {
                    bingo = false;
                    break;
                }
            }
            if (bingo) count++;
        }

        for (int i = 0; i < size; i++) {
            bingo = true;
            for (int j = 0; j < size; j++) {
                if (board[j][i] != 0) {
                    bingo = false;
                    break;
                }
            }
            if (bingo) count++;
        }

        for (int i = 0; i < size; i++) {
            bingo = true;
            if (board[i][i] != 0) {
                bingo = false;
                break;
            }
        }

        if (bingo) count++;

        for (int i = 0; i < size; i++) {
            bingo = true;
            if (board[i][4-i] != 0) {
                bingo = false;
                break;
            }
        }

        if (bingo) count++;

        return (count >= 3) ? true : false;
    }
}
