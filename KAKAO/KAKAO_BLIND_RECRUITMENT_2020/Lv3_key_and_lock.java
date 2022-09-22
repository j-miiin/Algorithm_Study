package kakao_blind_recruitment_2020;

// 2020 카카오 블라인드 채용 - 자물쇠와 열쇠
// https://school.programmers.co.kr/learn/courses/30/lessons/60059

import java.util.Arrays;

public class Lv3_key_and_lock {

    public static int N, M;
    public static int[][] big_lock;

    public static void main(String[] args) {

        int[][] key = {{0, 0, 0}, {1, 0, 0}, {0, 1, 1}};
        int[][] lock = {{1, 1, 1}, {1, 1, 0}, {1, 0, 1}};

        System.out.println(solution(key, lock));
    }

    public static boolean solution(int[][] key, int[][] lock) {

        N = lock.length;
        M = key.length;

        big_lock = new int[N*3][N*3];
        for (int[] i : big_lock) {
            Arrays.fill(i, 1);
        }
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                big_lock[i+N][j+N] = lock[i][j];
            }
        }

        boolean answer = false;
        int[][] new_key = key;
        for (int i = 0; i < 4; i++) {
            new_key = rotate_90(new_key);
            answer = match_key_and_lock(new_key);
            if (answer) return true;
        }

        return answer;
    }

    public static int[][] rotate_90 (int[][] origin) {
        int[][] target = new int[M][M];

        for (int i = 0; i < M; i++) {
            for (int j = 0; j < M; j++) {
                target[j][M-i-1] = origin[i][j];
            }
        }
        return target;
    }

    public static boolean match_key_and_lock(int[][] key) {

        for (int lockX = 0; lockX < N*2; lockX++) {
            for (int lockY = 0; lockY < N*2; lockY++) {
                for (int keyX = 0; keyX < M; keyX++) {
                    for (int keyY = 0; keyY < M; keyY++) {
                        big_lock[lockX + keyX][lockY + keyY] += key[keyX][keyY];
                    }
                }

                if (isRight()) return true;

                for (int keyX = 0; keyX < M; keyX++) {
                    for (int keyY = 0; keyY < M; keyY++) {
                        big_lock[lockX + keyX][lockY + keyY] -= key[keyX][keyY];
                    }
                }
            }
        }

        return false;
    }

    public static boolean isRight() {

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (big_lock[i+N][j+N] != 1) return false;
            }
        }
        return true;
    }
}
