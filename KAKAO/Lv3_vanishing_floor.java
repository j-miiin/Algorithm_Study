
// 2022 카카오 블라인드 채용

public class Lv3_vanishing_floor {

    private static final int EMPTY = 0;
    private static final int FLOOR = 1;

    public static int[] dx = {-1, 1, 0, 0};
    public static int[] dy = {0, 0, -1, 1};

    public static int N, M;
    public static int[][] gameBoard;
    public static boolean[][] visited;

    public static void main(String[] args) {
//        int[][] board = {{1, 1, 1}, {1, 1, 1}, {1, 1, 1}};
//        int[] aloc = {1, 0};
//        int[] bloc = {1, 2};

        int[][] board = {{1, 1, 1}, {1, 0, 1}, {1, 1, 1}};
        int[] aloc = {1, 0};
        int[] bloc = {1, 2};

//        int[][] board = {{1, 1, 1, 1, 1}};
//        int[] aloc = {0, 0};
//        int[] bloc = {0, 4};

//        int[][] board = {{1}};
//        int[] aloc = {0, 0};
//        int[] bloc = {0, 0};

        System.out.println(solution(board, aloc, bloc));
    }

    public static int solution(int[][] board, int[] aloc, int[] bloc) {

        gameBoard = board;
        N = board.length;
        M = board[0].length;
        visited = new boolean[N][M];

        int answer = playGame(aloc[0], aloc[1], bloc[0], bloc[1]);
        return answer;
    }

    public static int playGame(int myX, int myY, int opX, int opY) {

        if (visited[myX][myY]) return 0;

        int turn = 0;

        for (int i = 0; i < 4; i++) {
            int nextX = myX + dx[i];
            int nextY = myY + dy[i];

            if (nextX >= 0 && nextY >= 0 && nextX < N && nextY < M
                    && !visited[nextX][nextY] && gameBoard[nextX][nextY] == FLOOR) {

                visited[myX][myY] = true;

                int result = playGame(opX, opY, nextX, nextY) + 1;

                visited[myX][myY] = false;

                if (turn % 2 == 0 && result % 2 == 1) turn = result;
                else if (turn % 2 == 0 && result % 2 == 0) turn = Math.max(turn, result);
                else if (turn % 2 == 1 && result % 2 == 1) turn = Math.min(turn, result);
            }
        }

        return turn;
    }
}
