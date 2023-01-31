package baekjoon.math;

// 백준 - 에라토스테네스의 체 2960
// https://www.acmicpc.net/problem/2960

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class eratosthenes_2960 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());

        int count = 0;
        boolean[] check = new boolean[N+1];
        check[0] = check[1] = true;
        while (true) {
            int prime = 0;
            for (int i = 2; i <= N; i++) {
                if (!check[i]) {
                    prime = i;
                    check[i] = true;
                    count++;
                    break;
                }
            }

            if (count == K) {
                System.out.println(prime);
                return;
            }

            for (int i = prime*prime; i <= N; i+=prime) {
                if (!check[i]) {
                    check[i] = true;
                    count++;
                    if (count == K) {
                        System.out.println(i);
                        return;
                    }
                }
            }
        }
    }
}
