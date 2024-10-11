package baekjoon;

// 백준 - 연속합 1912
// https://www.acmicpc.net/problem/1912

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class serial_sum_1912 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());
        int[] numArr = new int[n];
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < n; i++) {
            numArr[i] = Integer.parseInt(st.nextToken());
        }

        int[] sum = new int[n];
        sum[0] = numArr[0];
        int result = Math.max(sum[0], Integer.MIN_VALUE);
        for (int i = 1; i < n; i++) {
            sum[i] = Math.max(sum[i-1] + numArr[i], numArr[i]);
            result = Math.max(result, sum[i]);
        }

        System.out.println(result);
    }
}
