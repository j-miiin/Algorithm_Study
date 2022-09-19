package programmers;

// 프로그래머스 월간 코드 챌린지 시즌 3-  N^2 배열 자르기
// https://school.programmers.co.kr/learn/courses/30/lessons/87390

public class Lv2_cut_array {
    public static void main(String[] args) {

        int n = 4;
        long left = 7;
        long right = 14;

        int[] result = solution(n, left, right);
        for (int i : result) {
            System.out.println(i);
        }
    }

    public static int[] solution(int n, long left, long right) {

        int[] answer = new int[(int)(right - left + 1)];
        int idx = 0;
        for (long i = left; i <= right; i++) {
            answer[idx++] = (int) (Math.max((i / n), (i % n)) + 1);
        }
        return answer;
    }
}
