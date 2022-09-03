
// BAEKJOON Gold 4
// Puyo Puyo : https://www.acmicpc.net/problem/11559

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;

public class week01_11559 {

    private static final int xLengthOfMap = 12;
    private static final int yLengthOfMap = 6;

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

    public static int popCount = 0;
    public static int result = 0;

    public static Queue<int[]> queue = new LinkedList<>();

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        puyoArr = new int[12][6];
        visited = new boolean[12][6];

        for (int i = 0; i < xLengthOfMap; i++) {
            String str = br.readLine();
            for (int j = 0; j < yLengthOfMap; j++) {
                Character c = str.charAt(j);
                if (c == '.') {
                    puyoArr[i][j] = EMPTY;
                } else if (c == 'R') {
                    puyoArr[i][j] = RED;
                } else if (c == 'G') {
                    puyoArr[i][j] = GREEN;
                } else if (c == 'B') {
                    puyoArr[i][j] = BLUE;
                } else if (c == 'P') {
                    puyoArr[i][j] = PURPLE;
                } else if (c == 'Y') {
                    puyoArr[i][j] = YELLOW;
                }
            }
        }

        while (true) {
            visited = new boolean[xLengthOfMap][yLengthOfMap];
            popCount = 0;

            for (int i = 0; i < xLengthOfMap; i++) {
                for (int j = 0; j < yLengthOfMap; j++) {
                    if (puyoArr[i][j] != EMPTY && !visited[i][j]) {
                        findSamePuyo(i, j);
                    }
                }
            }

            if (popCount == 0) {
                break;
            } else {
                result++;
            }

            rearrangePuyo();
        }

        System.out.println(result);
    }

    public static void findSamePuyo(int x, int y) {

        int count = 0;
        ArrayList<int[]> popPuyoList = new ArrayList<>();

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});
        visited[x][y] = true;

        while(!queue.isEmpty()) {

            int[] cur = queue.poll();
            int curX = cur[0];
            int curY = cur[1];

            // 현재 탐색 중인 뿌요를 저장
            popPuyoList.add(new int[]{curX, curY});
            count++;

            for (int i = 0; i < 4; i++) {
                int nextX = curX + dx[i];
                int nextY = curY + dy[i];

                if (nextX >= 0 && nextY >= 0 && nextX < xLengthOfMap && nextY < yLengthOfMap && !visited[nextX][nextY]) {
                    int nextPuyo = puyoArr[nextX][nextY];
                    if (nextPuyo != EMPTY && puyoArr[curX][curY] == nextPuyo) {

                        queue.offer(new int[]{nextX, nextY});
                        visited[nextX][nextY] = true;
                    }
                }
            }

            // 4개 이상 모인 뿌요라면 터짐
            if (count >= 4) {
                popPuyo(popPuyoList);
                popCount++;
            }
        }
    }

    public static void popPuyo(ArrayList<int[]> popPuyoList) {
        // 리스트의 뿌요들을 EMPTY로 변경
        for (int i = 0; i < popPuyoList.size(); i++) {
            int[] temp = popPuyoList.get(i);
            int x = temp[0];
            int y = temp[1];

            puyoArr[x][y] = EMPTY;
        }
    }

    public static void rearrangePuyo() {
        // 아래에서부터 탐색하여 EMPTY가 아닌 곳을 찾음 (밑에 빈 공간이 있는 뿌요)
        for (int i = xLengthOfMap - 1; i >= 0; i--) {
            for (int j = yLengthOfMap - 1; j >= 0; j--) {
                if (puyoArr[i][j] != EMPTY) {
                    downPuyo(i, j);
                }
            }
        }
    }

    public static void downPuyo(int x, int y) {
        int targetIdx = -1;

        // 인자로 주어진 뿌요와 같은 줄이면서 뿌요보다 아래에 있는 부분을 탐색
        // 아래에서부터 탐색하여 가장 먼저 발견된 빈 공간에 인자로 주어진 뿌요를 넣음
        for (int i = xLengthOfMap - 1; i > x; i--) {
            if (puyoArr[i][y] == EMPTY) {
                targetIdx = i;
                break;
            }
        }

        if (targetIdx != -1) {
            int temp = puyoArr[x][y];
            puyoArr[x][y] = EMPTY;
            puyoArr[targetIdx][y] = temp;
        }
    }
}

