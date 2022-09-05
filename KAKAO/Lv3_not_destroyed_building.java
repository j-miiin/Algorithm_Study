
// 2022 카카오 블라인드 채용

public class Lv3_not_destroyed_building {
    public static void main(String[] args) {
        int[][] board = {{5, 5, 5, 5, 5},{5, 5, 5, 5, 5},{5, 5, 5, 5, 5},{5, 5, 5, 5, 5}};
        int[][] skill = {{1, 0, 0, 3, 4, 4},{1, 2, 0, 2, 3, 2},{2, 1, 0, 3, 1, 2},{1, 0, 1, 3, 3, 1}};

//        int[][] board = {{1, 2, 3},{4, 5, 6},{7, 8, 9}};
//        int[][] skill = {{1, 1, 1, 2, 2, 4},{1, 0, 0, 1, 1, 2}, {2, 2, 0, 2, 0, 100}};

        System.out.println(solution(board, skill));
    }

    public static int solution(int[][] board, int[][] skill) {

        int r = board.length;
        int c = board[0].length;

        int[][] cumulativeSumArr = new int[r+1][c+1];

        for (int i = 0; i < skill.length; i++) {
            useSkill(cumulativeSumArr, skill[i]);
        }

        makeCumulativeSum(cumulativeSumArr, r, c);

        destroyOrStrengthenBuilding(board, cumulativeSumArr, r, c);

        int notDestroyedBuilding = 0;
        for (int[] column: board) {
            for (int idx: column) {
                if (idx >= 1) notDestroyedBuilding++;
            }
        }

        int answer = notDestroyedBuilding;
        return answer;
    }

    public static void useSkill(int[][] cumulativeSumArr, int[] skill) {

        int type = skill[0];

        int r1 = skill[1];
        int c1 = skill[2];

        int r2 = skill[3];
        int c2 = skill[4];

        int degree = skill[5];

        if (type == 1) {
            cumulativeSumArr[r1][c1] -= degree;
            cumulativeSumArr[r2+1][c1] += degree;
            cumulativeSumArr[r1][c2+1] += degree;
            cumulativeSumArr[r2+1][c2+1] -= degree;
        } else {
            cumulativeSumArr[r1][c1] += degree;
            cumulativeSumArr[r2+1][c1] -= degree;
            cumulativeSumArr[r1][c2+1] -= degree;
            cumulativeSumArr[r2+1][c2+1] += degree;
        }
    }

    public static void makeCumulativeSum(int[][] cumulativeSumArr, int r, int c) {
        for (int i = 0; i <= r; i++) {
            for (int j = 1; j <= c; j++) {
                cumulativeSumArr[i][j] += cumulativeSumArr[i][j-1];
            }
        }

        for (int i = 0; i <= c; i++) {
            for (int j = 1; j <= r; j++) {
                cumulativeSumArr[j][i] += cumulativeSumArr[j-1][i];
            }
        }
    }

    public static void destroyOrStrengthenBuilding(int[][] board, int[][] cumulativeSumArr, int r, int c) {
        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                board[i][j] += cumulativeSumArr[i][j];
            }
        }
    }
}
