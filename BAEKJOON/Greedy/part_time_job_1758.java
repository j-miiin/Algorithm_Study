
// 백준 - 알바생 강호 1758
// https://www.acmicpc.net/problem/1758

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.Collections;

public class part_time_job_1758 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        Integer[] tips = new Integer[N];
        for (int i = 0; i < N; i++) tips[i] = Integer.parseInt(br.readLine());
        Arrays.sort(tips, Collections.reverseOrder());

        long tip = 0;
        for (int i = 0; i < N; i++) {
            long curTip = tips[i] - i;
            tip += (curTip > 0) ? curTip : 0;
        }
        System.out.println(tip);
    }
}
