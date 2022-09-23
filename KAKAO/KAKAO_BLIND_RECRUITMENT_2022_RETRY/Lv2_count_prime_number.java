package kakao_blind_recruitment_2022_retry;

// 2022 카카오 블라인드 채용 - Lv2 k진수에서 소수 개수 구하기 2번째 풀이
// https://school.programmers.co.kr/learn/courses/30/lessons/92335

public class Lv2_count_prime_number {
    public static void main(String[] args) {

        int n = 110011;
        int k = 10;

        System.out.println(solution(n, k));
    }

    public static int solution(int n, int k) {

        String k_nary = Integer.toString(n, k);
        k_nary = k_nary.replaceAll("0+", "0");

        int answer = 0;

        String[] split = k_nary.split("0");
        for (String s : split) {
            if (isPrimeNumber(Long.parseLong(s))) answer++;
        }

        return answer;
    }

    public static boolean isPrimeNumber(long num) {
        if (num == 1) return false;
        if (num == 2 || num == 3) return true;
        for (int i = 2; i <= Math.sqrt(num); i++) {
            if (num % i == 0) return false;
        }

        return true;
    }
}
