package com.iifl.util;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.Inet4Address;
import java.net.InetAddress;
import java.net.InterfaceAddress;
import java.net.NetworkInterface;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.Enumeration;

import org.json.simple.JSONObject;

public class ServerDetails {

	public static String GetAddress(String addressType) {
		String address = "";
		InetAddress lanIp = null;
		try {

			String ipAddress = null;
			Enumeration<NetworkInterface> net = null;
			net = NetworkInterface.getNetworkInterfaces();

			while (net.hasMoreElements()) {
				NetworkInterface element = net.nextElement();
				Enumeration<InetAddress> addresses = element.getInetAddresses();

				while (addresses.hasMoreElements() && element.getHardwareAddress().length > 0
						&& !isVMMac(element.getHardwareAddress())) {
					InetAddress ip = addresses.nextElement();
					if (ip instanceof Inet4Address) {

						if (ip.isSiteLocalAddress()) {
							ipAddress = ip.getHostAddress();
							lanIp = InetAddress.getByName(ipAddress);
						}

					}

				}
			}

			if (lanIp == null)
				return null;
			if (addressType.equals("ip")) {
				address = lanIp.toString().replaceAll("^/+", "");
			} else if (addressType.equals("mac")) {
				address = getMacAddress(lanIp);
			} else {
				throw new Exception("Specify \"ip\" or \"mac\"");
			}

		} catch (UnknownHostException ex) {
			ex.printStackTrace();
		} catch (SocketException ex) {
			ex.printStackTrace();
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return address;

	}

	private static String getMacAddress(InetAddress ip) {
		String address = null;
		try {

			NetworkInterface network = NetworkInterface.getByInetAddress(ip);
			byte[] mac = network.getHardwareAddress();

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < mac.length; i++) {
				sb.append(String.format("%02X%s", mac[i], (i < mac.length - 1) ? "-" : ""));
			}
			address = sb.toString();

		} catch (SocketException ex) {

			ex.printStackTrace();

		}

		return address;
	}

	private static boolean isVMMac(byte[] mac) {
		if (null == mac)
			return false;
		byte invalidMacs[][] = { { 0x00, 0x05, 0x69 }, // VMWare
				{ 0x00, 0x1C, 0x14 }, // VMWare
				{ 0x00, 0x0C, 0x29 }, // VMWare
				{ 0x00, 0x50, 0x56 }, // VMWare
				{ 0x08, 0x00, 0x27 }, // Virtualbox
				{ 0x0A, 0x00, 0x27 }, // Virtualbox
				{ 0x00, 0x03, (byte) 0xFF }, // Virtual-PC
				{ 0x00, 0x15, 0x5D } // Hyper-V
		};

		for (byte[] invalid : invalidMacs) {
			if (invalid[0] == mac[0] && invalid[1] == mac[1] && invalid[2] == mac[2])
				return true;
		}

		return false;
	}

	public static String GetMacAddress() throws UnknownHostException, SocketException {

		InetAddress localHost = InetAddress.getLocalHost();

		NetworkInterface ni = NetworkInterface.getByInetAddress(localHost);

		byte[] hardwareAddress = ni.getHardwareAddress();
		String[] hexadecimal = new String[hardwareAddress.length];
		for (int i = 0; i < hardwareAddress.length; i++) {
			hexadecimal[i] = String.format("%02X", hardwareAddress[i]);
		}
		String macAddress = String.join("-", hexadecimal);
		return macAddress;
	}

	public static String GetSerialNo() throws UnknownHostException, SocketException {
		String macAddress = null;
		Enumeration<NetworkInterface> networkInterfaces = NetworkInterface.getNetworkInterfaces();
		while (networkInterfaces.hasMoreElements()) {
			NetworkInterface ni = networkInterfaces.nextElement();
			byte[] hardwareAddress = ni.getHardwareAddress();

			if (hardwareAddress != null) {
				String[] hexadecimalFormat = new String[hardwareAddress.length];
				for (int i = 0; i < hardwareAddress.length; i++) {
					hexadecimalFormat[i] = String.format("%02X", hardwareAddress[i]);
				}

				macAddress = String.join("-", hexadecimalFormat);
			}

		}
		return macAddress;
	}

	public static String GetMachineId() throws UnknownHostException, SocketException {
		String OS = System.getProperty("os.name").toLowerCase();

		String machineId = null;
		if (OS.indexOf("win") >= 0) {
			StringBuffer output = new StringBuffer();
			Process process;
			String[] cmd = { "wmic", "csproduct", "get", "UUID" };
			try {
				process = Runtime.getRuntime().exec(cmd);
				process.waitFor();
				BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));
				String line = "";
				while ((line = reader.readLine()) != null) {
					output.append(line + "\n");
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
			machineId = output.toString();
		} else if (OS.indexOf("nix") >= 0 || OS.indexOf("nux") >= 0 || OS.indexOf("aix") > 0) {
			machineId = GetLinuxMotherBoard_serialNumber();
			System.out.println("machineId : :  " + machineId);
		}
		return machineId;
	}

	private static String GetLinuxMotherBoard_serialNumber() {
		String command = "dmidecode -s baseboard-serial-number";
		String sNum = null;
		try {
			Process SerNumProcess = Runtime.getRuntime().exec(command);
			BufferedReader sNumReader = new BufferedReader(new InputStreamReader(SerNumProcess.getInputStream()));
			sNum = sNumReader.readLine().trim();
			SerNumProcess.waitFor();
			sNumReader.close();
		} catch (Exception ex) {
			System.err.println("Linux Motherboard Exp : " + ex.getMessage());
			sNum = null;
		}
		return sNum;
	}

	public static JSONObject GetIP() throws SocketException {
		final JSONObject requestHead = new JSONObject();
		for (final Enumeration<NetworkInterface> interfaces = NetworkInterface.getNetworkInterfaces(); interfaces
				.hasMoreElements();) {
			final NetworkInterface cur = interfaces.nextElement();

			if (cur.isLoopback()) {
				continue;
			}
			for (final InterfaceAddress addr : cur.getInterfaceAddresses()) {
				final InetAddress inet_addr = addr.getAddress();
				if (!(inet_addr instanceof Inet4Address)) {
					continue;
				}
				requestHead.put("publicIp", inet_addr.getHostAddress());
				requestHead.put("privateIp", addr.getBroadcast().getHostAddress());
			}
		}
		return requestHead;
	}

}
