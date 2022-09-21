package kakao_internship_2020;

// 2020 카카오 채용연계형 인턴십 - Lv1 키패드 누르기
// https://school.programmers.co.kr/learn/courses/30/lessons/67256

public class Lv1_touch_keypad {
    public static void main(String[] args) {

//        int[] numbers = {1, 3, 4, 5, 8, 2, 1, 4, 5, 9, 5};
//        String hand = "right";

//        int[] numbers = {7, 0, 8, 2, 8, 3, 1, 5, 7, 6, 2};
//        String hand = "left";

        int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
        String hand = "right";

        System.out.println(solution(numbers, hand));
    }

    public static String solution(int[] numbers, String hand) {

        int[][] dist = initDist();
        StringBuilder sb = new StringBuilder();
        int left = 10, right = 12;

        for (int i = 0; i < numbers.length; i++) {
            int cur = numbers[i];
            if (cur == 1 || cur == 4 || cur == 7) {
                sb.append("L");
                left = cur;
            }
            else if (cur == 3 || cur == 6 || cur == 9) {
                sb.append("R");
                right = cur;
            }
            else {
                int d = dist[cur][left] - dist[cur][right];
                if (d == 0) {
                    if (hand.equals("left")) {
                        sb.append("L");
                        left = cur;
                    } else {
                        sb.append("R");
                        right = cur;
                    }
                } else if (d > 0) {
                    sb.append("R");
                    right = cur;
                } else {
                    sb.append("L");
                    left = cur;
                }
            }
        }

        String answer = sb.toString();
        return answer;
    }

    public static int[][] initDist() {
        int[][] dist = new int[13][13]; // * : 10, # : 12

        // 거리 1
        for (int i = 2; i <= 8; i += 3) {
            dist[i][i-1] = dist[i][i+1] = 1;
        }
        dist[0][10] = dist[0][11] = 1;
        for (int i = 2; i <= 5; i += 3) {
            dist[i][i+3] = dist[i+3][i] = 1;
        }
        dist[8][0] = dist[0][8] = 1;

        // 거리 2
        for (int i = 2; i <= 8; i += 3) {
            dist[i][i+2] = dist[i][i+4] = 2;
        }
        for (int i = 8; i >= 5; i -= 3) {
            dist[i][i-4] = dist[i][i-2] = 2;
        }
        dist[0][7] = dist [0][9] = 2;
        dist[2][8] = dist[8][2] = 2;
        dist[5][0] = dist[0][5] = 2;

        // 거리 3
        for (int i = 2; i <= 5; i += 3) {
            dist[i][i+5] = dist[i][i+7] = 3;
        }
        dist[8][1] = dist[8][3] = 3;
        dist[0][4] = dist[0][6] = 3;
        dist[2][0] = dist[0][2] = 3;

        // 거리 4
        dist[2][10] = dist[2][12] = 4;
        dist[0][1] = dist[0][3] = 4;

        return dist;
    }
}
