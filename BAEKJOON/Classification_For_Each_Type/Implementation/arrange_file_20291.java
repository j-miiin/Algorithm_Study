package baekjoon.implementation;

// 백준 - 파일 정리 20291
// https://www.acmicpc.net/problem/20291

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;

public class arrange_file_20291 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        HashMap<String, Integer> map = new HashMap<>();
        for (int i = 0; i < N; i++) {
            String[] cur = br.readLine().split("[.]");
            String str = cur[1];
            map.put(str, map.getOrDefault(str, 0) + 1);
        }

        ArrayList<String> keyList = new ArrayList<>(map.keySet());
        Collections.sort(keyList);
        for (String key: keyList) {
            System.out.println(key + " " + map.get(key));
        }
    }
}
