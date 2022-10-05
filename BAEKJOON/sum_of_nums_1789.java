
// 백준 - 수들의 합 1789
// https://www.acmicpc.net/problem/1789

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class sum_of_nums_1789 {

    public static long S;
    public static long answer = 0;

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        S = Long.parseLong(br.readLine());

        binarySearch(1, S);
        System.out.println(answer);
    }

    public static void binarySearch(long start, long end) {

        if (start <= end) {
            long mid = (start + end) / 2;

            long cur = mid * (mid + 1) / 2;
            if (cur == S) {
                answer = mid;
                return;
            }
            else if (cur > S) {
                binarySearch(start, mid-1);
            }
            else {
                answer = Math.max(answer, mid);
                binarySearch(mid+1, end);
            }
        }
    }
}
