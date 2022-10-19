
// 백준 - 진법 변환 2745
// https://www.acmicpc.net/problem/2745

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class change_to_decimal_2745 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        String N = st.nextToken();
        int B = Integer.parseInt(st.nextToken());
        System.out.println(Long.parseLong(N, B));
    }
}
