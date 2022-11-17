
// 백준 - 소수 찾기 1978
// https://www.acmicpc.net/problem/1978

package baekjoon.math;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class find_prime_num_1978 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        StringTokenizer st = new StringTokenizer(br.readLine());
        int count = 0;
        for (int i = 0; i < N; i++) {
            int value = Integer.parseInt(st.nextToken());
            if (isPrime(value)) count++;
        }
        System.out.println(count);
    }

    public static boolean isPrime(int n) {
        if (n == 1) return false;
        if (n == 2 || n == 3) return true;

        for (int i = 2; i <= Math.sqrt(n); i++) {
            if (n % i == 0) return false;
        }
        return true;
    }
}
