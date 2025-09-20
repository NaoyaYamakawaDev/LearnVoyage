using System;
using System.ComponentModel.DataAnnotations;

namespace LearnVoyage.Server.Models;

public class User
{
    // primary key
    public int UserId { get; private set; }

    //C# 8 以降の「nullable reference types」では string に null を代入できない

    [Required(ErrorMessage = "名前の設定は必須です")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "名前の長さは1文字以上、30文字以内にしてください")]
    public string Name { get; private set; } = string.Empty;

    [Required(ErrorMessage = "メールアドレスの設定は必須です")]
    [EmailAddress(ErrorMessage = "メールアドレスとして適切な値を入力してください")]
    public string Mail { get; private set; } = string.Empty;

    [Required(ErrorMessage = "パスワードの設定は必須です")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "パスワードは8文字以上50字未満で設定してください")]
    public string Password { get; private set; } = string.Empty;
    
}