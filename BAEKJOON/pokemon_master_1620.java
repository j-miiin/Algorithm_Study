
// 백준 - 나는야 포켓몬 마스터 이다솜 1620
// https://www.acmicpc.net/problem/1620

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.StringTokenizer;

public class pokemon_master_1620 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int N = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());

        HashMap<String, String> nameMap = new HashMap<>();
        HashMap<String, String> numMap = new HashMap<>();
        for (int i = 1; i <= N; i++) {
            String name = br.readLine();
            nameMap.put(name, i+"");
            numMap.put(i+"", name);
        }

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < M; i++) {
            String key = br.readLine();
            sb.append((nameMap.get(key) == null) ? numMap.get(key) : nameMap.get(key)).append("\n");
        }

        System.out.println(sb);
    }
}
