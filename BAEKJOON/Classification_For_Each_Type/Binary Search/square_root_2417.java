package baekjoon.binary_search;

// 백준 - 정수 제곱근 2417
// https://www.acmicpc.net/problem/2417

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class square_root_2417 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        long n = Long.parseLong(br.readLine());

        long start = 0, end = (long)Math.sqrt(n);
        while (start <= end) {
            long mid = (start + end) / 2;
            long q = mid * mid;
            if (q < n) start = mid + 1;
            else if (q > n) end = mid-1;
            else {
                System.out.println(mid);
                return;
            }
        }
        System.out.println(start);
    }
}
