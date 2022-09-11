package kakao_blind_recruitment_2021;

// 2021 카카오 블라인드 채용

import java.util.LinkedList;
import java.util.Queue;

public class Lv3_pairing_card {

    public static final int EMPTY = 0;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int[][] gameBoard = new int[4][4];

    public static void main(String[] args) {

    }

    public static int solution(int[][] board, int r, int c) {
        gameBoard = board;

        int answer = 0;
        return answer;
    }

    public static void bfs(int x, int y) {

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{x, y});

        int enter = 0;


        while(!queue.isEmpty()) {

        }
    }
}
