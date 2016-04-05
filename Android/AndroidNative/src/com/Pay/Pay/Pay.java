package com.Pay.Pay;

import android.content.Intent;
import android.util.Log;
import android.app.Activity;

import com.AndroidToUnityMsgBridge.AndroidToUnityMsgBridge.AndroidToUnityMsgBridge;

public class Pay {
	// -------------------------------------------------------------------------
	private static Pay mPay;
	private AndroidToUnityMsgBridge mAndroidToUnityMsgBridge;
	private Activity mUnityActivity;
	private static final int REQUEST_CODE_PAYMENT = 1;

	// -------------------------------------------------------------------------
	public static Pay Instance(String pay_resultreceiver) {
		if (mPay == null) {
			mPay = new Pay(pay_resultreceiver);
		}

		return mPay;
	}

	// -------------------------------------------------------------------------
	private Pay(String pay_resultreceiver) {
		this.mAndroidToUnityMsgBridge = AndroidToUnityMsgBridge
				.Instance(pay_resultreceiver);
		this.mUnityActivity = this.mAndroidToUnityMsgBridge.getActivity();
	}

	// -------------------------------------------------------------------------
	public void pay(String pay_chargedata) {
		Intent intent = new Intent(this.mUnityActivity,
				com.pingplusplus.android.PaymentActivity.class);
		Log.e("Pay", "pay1::" + pay_chargedata);
		intent.putExtra(com.pingplusplus.android.PaymentActivity.EXTRA_CHARGE,
				pay_chargedata);
		Log.e("Pay", "pay2::" + pay_chargedata);
		this.mUnityActivity
				.startActivityForResult(intent, REQUEST_CODE_PAYMENT);
		Log.e("Pay", "pay3::" + pay_chargedata);

		this.mAndroidToUnityMsgBridge.sendMsgToUnity("test",
				"Pay::Success!!!!!!");
	}

}
