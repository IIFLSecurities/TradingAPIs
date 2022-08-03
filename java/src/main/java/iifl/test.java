package iifl;

import java.io.IOException;

import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.junit.internal.TextListener;
import org.junit.runner.JUnitCore;

import com.iifl.api.Exchange;

public class test {

	static Exchange apis = new Exchange();
	static JSONParser parser = new JSONParser();

	public static void main(String[] args) throws IOException, ParseException, NoSuchFieldException, SecurityException,
			IllegalArgumentException, IllegalAccessException {
		JUnitCore junit = new JUnitCore();
		junit.addListener(new TextListener(System.out));
		junit.run(test2.class);

	}

}
