package baekjoon;

// 백준 5052 전화번호 목록

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

class TrieNode {
    private Map<Character, TrieNode> childNodes = new HashMap<>();
    private boolean isLast;

    public Map<Character, TrieNode> getChildNodes() {
        return childNodes;
    }

    public boolean isLast() {
        return isLast;
    }

    public void setLast(boolean last) {
        isLast = last;
    }
}

public class phone_number_list_5052 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();

        int t = Integer.parseInt(br.readLine());

        for (int i = 0; i < t; i++) {
            int n = Integer.parseInt(br.readLine());
            String[] arr = new String[n];
            TrieNode rootNode = initRootTrieNode();
            for (int j = 0; j < n; j++) {
                arr[j] = br.readLine();
                insert(rootNode, arr[j]);
            }

            boolean consistency = true;
            for (String s : arr) {
                if(!isConsistent(rootNode, s)) {
                    consistency = false;
                    break;
                }
            }
            sb.append(consistency ? "YES" : "NO").append('\n');
        }

        System.out.println(sb);
    }

    public static TrieNode initRootTrieNode() {
        return new TrieNode();
    }

    public static void insert(TrieNode rootNode, String word) {
        TrieNode node = rootNode;

        for (int i = 0; i < word.length(); i++) {
            node = node.getChildNodes().computeIfAbsent(word.charAt(i), c -> new TrieNode());
        }
        node.setLast(true);
    }

    public static boolean isConsistent(TrieNode rootNode, String word) {
        TrieNode node = rootNode;
        char cur;

        for (int i = 0; i < word.length(); i++) {
            cur = word.charAt(i);
            if (i != word.length() - 1 && node.getChildNodes().get(cur).isLast()) return false;
            node = node.getChildNodes().get(cur);
        }
        return true;
    }
}
