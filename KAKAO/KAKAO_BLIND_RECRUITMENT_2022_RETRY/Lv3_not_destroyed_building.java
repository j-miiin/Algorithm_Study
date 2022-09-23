package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv3 파괴되지 않은 건물 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92344

public class Lv3_not_destroyed_building {

    public static final int ATTACK = 1, RESTORE = 0;
    public static int N, M;

    public static void main(String[] args) {
//        int[][] board = {{5, 5, 5, 5, 5},{5, 5, 5, 5, 5},{5, 5, 5, 5, 5},{5, 5, 5, 5, 5}};
//        int[][] skill = {{1, 0, 0, 3, 4, 4},{1, 2, 0, 2, 3, 2},{2, 1, 0, 3, 1, 2},{1, 0, 1, 3, 3, 1}};

        int[][] board = {{1, 2, 3},{4, 5, 6},{7, 8, 9}};
        int[][] skill = {{1, 1, 1, 2, 2, 4},{1, 0, 0, 1, 1, 2}, {2, 2, 0, 2, 0, 100}};

        System.out.println(solution(board, skill));
    }

    public static int solution(int[][] board, int[][] skill) {

        N = board.length;
        M = board[0].length;
        int[][] skillSum = new int[N+1][M+1];

        for (int i = 0; i < skill.length; i++) {
            int type = skill[i][0];
            int r1 = skill[i][1], c1 = skill[i][2];
            int r2 = skill[i][3], c2 = skill[i][4];
            int degree = skill[i][5];

            if (type == ATTACK) {
                skillSum[r1][c1] -= degree; skillSum[r2+1][c2+1] -= degree;
                skillSum[r2+1][c1] += degree; skillSum[r1][c2+1] += degree;
            } else {
                skillSum[r1][c1] += degree; skillSum[r2+1][c2+1] += degree;
                skillSum[r2+1][c1] -= degree; skillSum[r1][c2+1] -= degree;
            }
        }

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) skillSum[i][j+1] += skillSum[i][j];
        }

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) skillSum[i+1][j] += skillSum[i][j];
        }

        int answer = 0;
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) {
                skillSum[i][j] += board[i][j];
                if (skillSum[i][j] > 0) answer++;
            }
        }
        return answer;
    }
}
