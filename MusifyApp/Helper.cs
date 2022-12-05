using System;
using System.Collections.Generic;
using System.Text;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MusifyApp
{
	public class Helper
	{
        
        public static AmazonS3Client s3Client = GetAmazonS3Client();

        private static AmazonS3Client GetAmazonS3Client()
        {

            string accesskeyID = "AKIAQ7HDDSODZPR4J7H7";
            string secretKey = "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";

            BasicAWSCredentials credentials = new BasicAWSCredentials(accesskeyID, secretKey);
            s3Client = new AmazonS3Client(credentials, RegionEndpoint.CACentral1);
            return s3Client;
        }

    }
}

