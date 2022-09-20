package baekjoon;

// 백준 - 에너지 드링크 20115
// https://www.acmicpc.net/problem/20115

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.util.StringTokenizer;

public class energy_drink_20115 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        int N = Integer.parseInt(br.readLine());
        double[] drink = new double[N];
        StringTokenizer st = new StringTokenizer(br.readLine());
        for (int i = 0; i < N; i++) {
            drink[i] = Double.parseDouble(st.nextToken());
        }

        Arrays.sort(drink);
        for (int i = 0; i < N-1; i++) {
            drink[i] /= 2;
        }

        double result = 0;
        for (double d : drink) result += d;
        System.out.println(result);
    }
}
