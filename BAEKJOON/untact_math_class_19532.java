
// 백준 - 수학은 비대면 강의입니다 19532
// https://www.acmicpc.net/problem/19532

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class untact_math_class_19532 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int a = Integer.parseInt(st.nextToken());
        int b = Integer.parseInt(st.nextToken());
        int c = Integer.parseInt(st.nextToken());
        int d = Integer.parseInt(st.nextToken());
        int e = Integer.parseInt(st.nextToken());
        int f = Integer.parseInt(st.nextToken());

        StringBuilder sb = new StringBuilder();
        for (int i = -999; i <= 999; i++) {
            for (int j = -999; j <= 999; j++) {
                if ((a*i + b*j == c) && (d*i + e*j == f)) {
                    sb.append(i).append(" ").append(j);
                    break;
                }
            }
        }
        System.out.println(sb);
    }
}
