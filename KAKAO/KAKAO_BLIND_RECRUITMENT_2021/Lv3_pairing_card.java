package kakao_blind_recruitment_2021;

// 2021 카카오 블라인드 채용

import java.util.LinkedList;
import java.util.Queue;

public class Lv3_pairing_card {

    public static final int EMPTY = 0;
    public static final int BOARD_SIZE = 4;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int[][] gameBoard = new int[4][4];
    public static int leftCard = 0;
    public static int result = Integer.MAX_VALUE;

    public static void main(String[] args) {
        int[][] boadr = {{1, 0, 0, 3}, {2, 0, 0, 0}, {0, 0, 0, 2}, {3, 0, 1, 0}};
        int r = 1;
        int c = 0;

        System.out.println(solution(boadr, r, c));
    }

    public static int solution(int[][] board, int r, int c) {
        gameBoard = board;

        for (int i = 0; i < BOARD_SIZE; i++) {
            for (int j = 0; j < BOARD_SIZE; j++) {
                if (board[i][j] != EMPTY) leftCard++;
            }
        }

        dfs(0, 0, r, c);
        int answer = result;
        return answer;
    }

    public static void dfs(int count, int enter, int curX, int curY) {

        if (leftCard == 0) {
            result = Math.min(result, count);
            return;
        }

        for (int i = 0; i < 8; i++) {
            if (i > 3) {
                int[] next = moveCursorWithCtrl(curX, curY, dx[i%4], dy[i%4]);
                int nextX = next[0];
                int nextY = next[1];

                if (nextX >= 0 && nextY >= 0 && nextX < BOARD_SIZE && nextY < BOARD_SIZE) {
                    if (enter % 2 == 0) {
                        if (gameBoard[curX][curY] != EMPTY) {
                            dfs(count++, enter++, nextX, nextY);
                        }
                    } else {
                        if ((gameBoard[curX][curY] != EMPTY) && (gameBoard[curX][curY] == gameBoard[nextX][nextY])) {
                            int tmp = gameBoard[curX][curY];
                            gameBoard[curX][curY] = EMPTY;
                            gameBoard[nextX][nextY] = EMPTY;
                            leftCard -= 2;
                            dfs(count++, enter++, nextX, nextY);
                            gameBoard[curX][curY] = tmp;
                            gameBoard[nextX][nextY] = tmp;
                            leftCard += 2;
                        } else {
                            dfs(count++, enter, nextX, nextY);
                        }
                    }
                }
            } else {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX >= 0 && nextY >= 0 && nextX < BOARD_SIZE && nextY < BOARD_SIZE) {
                    if (enter % 2 == 0) {
                        if (gameBoard[curX][curY] != EMPTY) {
                            dfs(count, enter++, nextX, nextY);
                        }
                    } else {
                        if ((gameBoard[curX][curY] != EMPTY) && (gameBoard[curX][curY] == gameBoard[nextX][nextY])) {
                            int tmp = gameBoard[curX][curY];
                            gameBoard[curX][curY] = EMPTY;
                            gameBoard[nextX][nextY] = EMPTY;
                            dfs(count++, enter++, nextX, nextY);
                            gameBoard[curX][curY] = tmp;
                            gameBoard[nextX][nextY] = tmp;
                        } else {
                            dfs(count, enter, nextX, nextY);
                        }
                    }
                }
            }
        }
    }

    public static int[] moveCursorWithCtrl(int x, int y, int xDir, int yDir) {
        int nextX = x, nextY = y;

        for (int i = 0; i < 3; i++) {
            nextX += xDir;
            nextY += yDir;
            if (nextX < 0 || nextY < 0 || nextX >= BOARD_SIZE || nextY >= BOARD_SIZE) {
                nextX -= xDir;
                nextY -= yDir;
                break;
            }
            else if (gameBoard[nextX][nextY] != EMPTY) break;
        }

        return new int[]{nextX, nextY};
    }
}
