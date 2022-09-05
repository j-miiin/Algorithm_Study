
// 2022 카카오 블라인드 채용

public class Lv2_find_num_of_prime_number {

    public static void main(String[] args) {
        System.out.println(solution(110011, 10));
    }

    public static int solution(int n, int k) {

        String k_naryNum = convertTo_K_nary_Num(n, k);

        k_naryNum = k_naryNum.replaceAll("0+", "0");

        String[] splitNumByZero = k_naryNum.split("0");

        int result = 0;
        for (String s: splitNumByZero) {
            Long cur = Long.parseLong(s);
            if (isPrimeNumber(cur)) {
                result++;
            }
        }

        int answer = result;
        return answer;
    }

    public static String convertTo_K_nary_Num(int n, int k){

        StringBuilder sb = new StringBuilder();

        int curNum = n;
        while (curNum > 0) {
            if (curNum % k < 10) {
                sb.append(curNum % k);
            } else {
                sb.append(curNum % k - 10 + 'A');
            }

            curNum /= k;
        }

        return sb.reverse().toString();
    }

    public static boolean isPrimeNumber(Long num) {
        if (num < 2) return false;

        for (int i = 2; i <= Math.sqrt(num); i++) {
            if (num % i == 0) return false;
        }
        return true;
    }
}
