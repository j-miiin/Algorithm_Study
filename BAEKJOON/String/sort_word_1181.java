
// 백준 - 단어 정렬 1181
// https://www.acmicpc.net/problem/1181

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class sort_word_1181 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());
        HashSet<String> set = new HashSet<>();
        for (int i = 0; i < N; i++) set.add(br.readLine());
        ArrayList<String> list = new ArrayList<>(set);
        Collections.sort(list);
        Collections.sort(list, new Comparator<String>() {
            @Override
            public int compare(String o1, String o2) {
                return o1.length() - o2.length();
            }
        });
        StringBuilder sb = new StringBuilder();
        for (String s : list) sb.append(s).append("\n");
        System.out.println(sb);
    }
}
