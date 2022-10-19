
// 백준 - 귀찮아(SIB) 14929
// https://www.acmicpc.net/problem/14929

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class tiresome_14929 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());
        long[] arr = new long[n];
        long sum = 0;
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < n; i++) {
            int cur = Integer.parseInt(st.nextToken());
            if (i > 0) arr[i] = arr[i-1] + cur;
            else arr[i] = cur;
            sum += cur * cur;
        }

        System.out.println((arr[n-1]*arr[n-1] - sum) / 2);
    }
}
