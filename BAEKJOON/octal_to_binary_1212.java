
// 백준 - 8진수 2진수 1212
// https://www.acmicpc.net/problem/1212

package baekjoon;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.math.BigInteger;

public class octal_to_binary_1212 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        BigInteger n = new BigInteger(br.readLine(), 8);
        String binaryN = n.toString(2);
        System.out.println(binaryN);
    }
}
