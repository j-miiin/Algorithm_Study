package kakao_internship_2021;

// 2021 카카오 채용연계형 인턴십 - 거리두기 확인하기
// https://school.programmers.co.kr/learn/courses/30/lessons/81302#fn1

import java.util.ArrayList;
import java.util.Arrays;

public class Lv2_check_distance {

    public static final int EMPTY = 0;
    public static final int PERSON = 1;
    public static final int PARTITION = 2;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int N = 5;
    public static int[][] room;
    public static boolean[][] visited;
    public static ArrayList<String> possibleList;
    public static boolean check = true;

    public static void main(String[] args) {

        String[][] places = {{"POOOP", "OXXOX", "OPXPX", "OOXOX", "POXXP"}
        , {"POOPX", "OXPXP", "PXXXO", "OXXXO", "OOOPP"}
        , {"PXOPX", "OXOXP", "OXPOX", "OXXOP", "PXPOX"}
        , {"OOOXX", "XOOOX", "OOOXX", "OXOOX", "OOOOO"}
        , {"PXPXP", "XPXPX", "PXPXP", "XPXPX", "PXPXP"}};
        int[] result = solution(places);

        for (int i : result) System.out.println(i);
    }

    public static int[] solution(String[][] places) {

        int[] answer = new int[N];
        String[] possibleArr = {"100", "122", "102", "120", "121"};
        possibleList = new ArrayList<>(Arrays.asList(possibleArr));

        for (int i = 0; i < N; i++) {

            String[] str = places[i];
            room = new int[N][N];
            ArrayList<int[]> personPosList = new ArrayList<>();

            for (int j = 0; j < N; j++) {
                String s = str[j];

                for (int k = 0; k < s.length(); k++) {
                    char c = s.charAt(k);
                    if (c == 'P') {
                        room[j][k] = PERSON;
                        personPosList.add(new int[]{j, k});
                    }
                    else if (c == '0') room[j][k] = EMPTY;
                    else if (c == 'X') room[j][k] = PARTITION;
                }
            }

            for (int[] person : personPosList) {
                int x = person[0];
                int y = person[1];
                String s = room[x][y] + "";
                visited = new boolean[N][N];
                visited[x][y] = true;
                dfs(x, y, 0, s);
                if (!check) break;
            }

            answer[i] = check ? 1 : 0;

            check = true;
        }

        return answer;
    }

    public static void dfs(int x, int y, int dist, String str) {

        if (!check) return;

        int curX = x;
        int curY = y;

        if (dist == 2) {
            if (!possibleList.contains(str)) check = false;
            return;
        }

        for (int i = 0; i < 4; i++) {
            int nextX = curX + dx[i];
            int nextY = curY + dy[i];

            if (nextX < 0 || nextY < 0 || nextX >= N || nextY >= N) continue;

            if (!visited[nextX][nextY]) {
                visited[nextX][nextY] = true;
                dfs(nextX, nextY, dist + 1, str + room[nextX][nextY]);
            }
        }
    }
}
