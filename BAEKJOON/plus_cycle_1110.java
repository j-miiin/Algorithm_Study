
// 백준 - 더하기 사이클 1110
// https://www.acmicpc.net/problem/1110

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class plus_cycle_1110 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        int originNum = N;
        int newNum = 0;
        int cycle = 0;
        while (true) {
            newNum = originNum / 10 + originNum % 10;
            int tmp1 = originNum % 10;
            int tmp2 = newNum % 10;
            originNum = tmp1*10 + tmp2;
            cycle++;
            if (originNum == N) break;
        }
        System.out.println(cycle);
    }
}
