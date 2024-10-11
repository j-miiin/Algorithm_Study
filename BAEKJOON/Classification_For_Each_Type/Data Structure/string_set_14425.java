
// 백준 - 문자열 집합 14425
// https://www.acmicpc.net/problem/14425

package baekjoon.data_structure;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.StringTokenizer;

public class string_set_14425 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());

        ArrayList<String> strList = new ArrayList<>();
        for (int i = 0; i < N; i++) strList.add(br.readLine());

        int count = 0;
        for (int i = 0; i < M; i++) {
            String str = br.readLine();
            if (strList.contains(str)) count++;
        }
        System.out.println(count);
    }
}
