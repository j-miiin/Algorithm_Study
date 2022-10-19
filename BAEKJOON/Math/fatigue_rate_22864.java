
// 백준 - 피로도 22864
// https://www.acmicpc.net/problem/22864

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class fatigue_rate_22864 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int A = Integer.parseInt(st.nextToken());
        int B = Integer.parseInt(st.nextToken());
        int C = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());

        int result = 0;
        int curFatigue = 0;
        for (int i = 1; i <= 24; i++) {
            if (curFatigue + A <= M) {
                curFatigue += A;
                result += B;
            } else {
                curFatigue -= C;
                if (curFatigue < 0) curFatigue = 0;
            }
        }

        System.out.println(result);
    }
}
