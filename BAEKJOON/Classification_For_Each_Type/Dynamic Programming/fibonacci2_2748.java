
// 백준 - 피보나치 수 2 2748
// https://www.acmicpc.net/problem/2748

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class fibonacci2_2748 {

    public static long[] fibonacci;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());
        fibonacci = new long[n+1];
        System.out.println(makeFibonacci(n));
    }

    public static long makeFibonacci(int x) {
        if (x == 0) return 0;
        if (x == 1) return 1;
        if (fibonacci[x] != 0) return fibonacci[x];
        return fibonacci[x] = makeFibonacci(x-1) + makeFibonacci(x-2);
    }
}
